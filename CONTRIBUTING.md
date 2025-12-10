# Contributing to RWA-DeFi-Contract

Thank you for your interest in contributing to RWA-DeFi-Contract! This document provides guidelines and instructions for contributing.

## Code of Conduct

- Be respectful and inclusive
- Focus on constructive feedback
- Follow the project's coding standards
- Be patient with questions and reviews

## Getting Started

1. Fork the repository
2. Clone your fork: `git clone https://github.com/your-username/RWA-DeFi-Contract.git`
3. Create a branch: `git checkout -b feature/your-feature-name`
4. Make your changes
5. Test your changes thoroughly
6. Commit with clear messages
7. Push to your fork: `git push origin feature/your-feature-name`
8. Open a Pull Request

## Development Setup

### Prerequisites

- Foundry (latest version)
- Node.js (v16+)
- Git

### Setup Steps

```bash
# Install Foundry dependencies
forge install

# Install Node.js dependencies
npm install

# Run tests to verify setup
forge test
```

## Coding Standards

### Solidity Style Guide

- Follow [Solidity Style Guide](https://docs.soliditylang.org/en/latest/style-guide.html)
- Use `SPDX-License-Identifier` in all files
- Use explicit visibility for all functions and state variables
- Use `internal` for library functions
- Use `private` for internal state variables
- Follow naming conventions:
  - Contracts: `PascalCase`
  - Functions: `camelCase`
  - Events: `PascalCase`
  - Constants: `UPPER_SNAKE_CASE`
  - State variables: `_camelCase` (with underscore prefix)

### Code Formatting

- Use 4 spaces for indentation
- Maximum line length: 120 characters
- Add comments for complex logic
- Use NatSpec comments for public functions

### Example

```solidity
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

/**
 * @title ExampleContract
 * @notice Example contract demonstrating coding standards
 */
contract ExampleContract {
    uint256 private constant MAX_VALUE = 1000;
    
    /**
     * @notice Example function with NatSpec
     * @param value The value to process
     * @return result The processed result
     */
    function processValue(uint256 value) external pure returns (uint256 result) {
        require(value <= MAX_VALUE, "Value too large");
        return value * 2;
    }
}
```

## Testing Requirements

### Test Coverage

- All new features must include tests
- Aim for >80% code coverage
- Include edge cases and error conditions
- Add fuzz tests for complex logic

### Running Tests

```bash
# Run all tests
forge test

# Run with verbosity
forge test -vvv

# Run specific test
forge test --match-test testFunctionName

# Check coverage
forge coverage
```

### Test Structure

```solidity
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

import {Test} from "forge-std/Test.sol";
import {ExampleContract} from "../contracts/ExampleContract.sol";

contract ExampleContractTest is Test {
    ExampleContract example;
    
    function setUp() public {
        example = new ExampleContract();
    }
    
    function test_ProcessValue() public {
        uint256 result = example.processValue(100);
        assertEq(result, 200);
    }
}
```

## Pull Request Process

### Before Submitting

1. ✅ All tests pass
2. ✅ Code follows style guide
3. ✅ Documentation updated (if needed)
4. ✅ No hardcoded values or secrets
5. ✅ Gas optimizations considered

### PR Description Template

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Testing
Describe tests added/updated

## Checklist
- [ ] Code follows style guidelines
- [ ] Tests added/updated
- [ ] Documentation updated
- [ ] No breaking changes (or documented)
```

### Review Process

- Maintainers will review within 48 hours
- Address feedback promptly
- Keep PRs focused and reasonably sized
- Rebase on main if conflicts arise

## Commit Messages

Use clear, descriptive commit messages:

```
Good: "Add two-slope interest rate model implementation"
Bad:  "fix stuff"
```

Format:
```
<type>(<scope>): <subject>

<body>

<footer>
```

Types: `feat`, `fix`, `docs`, `style`, `refactor`, `test`, `chore`

## Security Considerations

- Never commit private keys or secrets
- Review code for security vulnerabilities
- Consider gas optimization
- Test edge cases thoroughly
- Document security assumptions

## Questions?

- Open an issue for questions
- Check existing issues/PRs first
- Be patient for responses

Thank you for contributing! 🎉

