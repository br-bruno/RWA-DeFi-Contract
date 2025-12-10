# Quick Start Guide

Get up and running with RWA-DeFi-Contract in minutes.

## Prerequisites

- [Foundry](https://book.getfoundry.sh/getting-started/installation) installed
- [Node.js](https://nodejs.org/) v16+ installed
- Basic knowledge of Solidity and DeFi

## Installation

```bash
# Clone the repository
git clone https://github.com/earthskyorg/RWA-DeFi-Contract.git
cd RWA-DeFi-Contract

# Install Foundry dependencies
forge install

# Install Node.js dependencies
npm install
```

## Configuration

1. Create `.env` file (copy from `.env.example` if available):
```bash
# Add your configuration
MAINNET_RPC_URL=your_rpc_url
MNEMONIC=your_mnemonic_phrase
```

2. Update `hardhat.config.js` with your RPC URLs and API keys.

## Build

```bash
# Compile contracts
forge build

# Or with Hardhat
npm run compile
```

## Test

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

## Deploy (Local)

```bash
# Start local node
npx hardhat node

# In another terminal, deploy
forge script script/Deploy.s.sol --rpc-url http://localhost:8545 --broadcast
```

## Next Steps

- Read [ARCHITECTURE.md](ARCHITECTURE.md) to understand the system design
- Review [API.md](API.md) for interface documentation
- Check [DEPLOYMENT.md](DEPLOYMENT.md) for production deployment
- See [CONTRIBUTING.md](../CONTRIBUTING.md) to contribute

## Common Commands

```bash
# Format code
npm run format

# Lint Solidity
npm run lint

# Check contract sizes
npm run size

# Clean build artifacts
npm run clean
```

## Troubleshooting

### Foundry not found
```bash
curl -L https://foundry.paradigm.xyz | bash
foundryup
```

### Compilation errors
- Check Solidity version compatibility
- Verify all dependencies are installed: `forge install`
- Check remappings in `remappings.txt`

### Test failures
- Ensure local node is running (if needed)
- Check test environment setup
- Review test logs with `-vvv` flag

## Resources

- [Foundry Book](https://book.getfoundry.sh/)
- [Solidity Docs](https://docs.soliditylang.org/)
- [Hardhat Docs](https://hardhat.org/docs)

## Support

- [GitHub Issues](https://github.com/earthskyorg/RWA-DeFi-Contract/issues)
- [@Tech Genie](https://t.me/opensea712)
- [@Tech Genie](https://x.com/shinytechapes)

