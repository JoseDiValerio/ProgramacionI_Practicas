export const meta = {
  name: 'find-flaky-tests',
  description: 'Find flaky tests and propose fixes by scanning test logs and implementation patterns',
  phases: [{ title: 'Scan' }, { title: 'Fix' }],
};

// Schema for capturing test failure patterns
const TEST_PATTERN_SCHEMA = {
  type: "object",
  properties: {
    testName: { type: "string" },
    category: { type: "string", enum: ["timing", "data-race", "environment", "resource-leak", "async-ordering", "mock-issue", "state-dependency"] },
    confidence: { type: "string", enum: ["low", "medium", "high"] },
    pattern: { type: "string" },
    evidence: { type: "string" }
  },
  required: ["testName", "category", "confidence", "pattern", "evidence"]
};

// Schema for fix proposals
const FIX_SCHEMA = {
  type: "object",
  properties: {
    testName: { type: "string" },
    issue: { type: "string" },
    proposedFix: { type: "string" },
    codeSnippet: { type: "string" }
  },
  required: ["testName", "issue", "proposedFix"]
};

// Main workflow starts here
phase('Scan')
const logs = await agent('grep test logs for error patterns and timing variations', { schema: TEST_PATTERN_SCHEMA })
  .then(results => results.filter(Boolean))

log(`Found ${logs.length} potential flaky test candidates`)
await log('Analyzing each candidate...')

// Propose fixes based on pattern analysis
const fixes = await parallel(logs.map(test => () =>
  agent(`Propose fix for: ${test.testName}`, {
    phase: 'Fix',
    schema: FIX_SCHEMA,
    prompt: `This test appears flaky:\n\nTest name: ${test.testName}\nCategory: ${test.category}\nEvidence: ${test.evidence}\n\nBased on this evidence, identify the root cause and propose a concrete fix with code. For timing issues: add explicit waits or use timeouts. For data races: isolate state or synchronize access. For environment issues: ensure isolation between test runs.`
  })
))

return { flakyTests: logs.filter(Boolean), fixes }
