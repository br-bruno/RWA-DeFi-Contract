# Deployment Guide

## Prerequisites

- Foundry installed
- Node.js and npm installed
- Environment variables configured
- Sufficient funds for deployment

## Environment Setup

1. Copy the example environment file:
```bash
cp .env.example .env
```

2. Fill in your environment variables:
- RPC URLs for your target networks
- Wallet mnemonic or private key
- API keys for verification

## Deployment Steps

### Using Foundry

1. Build the contracts:
```bash
forge build
```

2. Run deployment script:
```bash
forge script script/Deploy.s.sol --rpc-url <network> --broadcast --verify
```

### Using Hardhat

1. Compile contracts:
```bash
npm run compile
```

2. Deploy to network:
```bash
npx hardhat run scripts/deploy.js --network <network>
```

## Network Configuration

### Mainnet

```bash
forge script script/Deploy.s.sol \
  --rpc-url $MAINNET_RPC_URL \
  --broadcast \
  --verify \
  --etherscan-api-key $ETHERSCAN_API_KEY
```

### Testnets

#### Sepolia
```bash
forge script script/Deploy.s.sol \
  --rpc-url $SEPOLIA_RPC_URL \
  --broadcast \
  --verify
```

#### Polygon Mumbai
```bash
forge script script/Deploy.s.sol \
  --rpc-url $POLYGON_MUMBAI_RPC_URL \
  --broadcast \
  --verify
```

## Verification

### Etherscan Verification

After deployment, verify contracts:

```bash
forge verify-contract <CONTRACT_ADDRESS> <CONTRACT_NAME> \
  --chain-id <CHAIN_ID> \
  --etherscan-api-key $ETHERSCAN_API_KEY
```

### Hardhat Verification

```bash
npx hardhat verify --network <network> <CONTRACT_ADDRESS> <CONSTRUCTOR_ARGS>
```

## Post-Deployment

1. **Verify Contracts**: Verify all deployed contracts on block explorer
2. **Initialize Protocol**: Call initialization functions
3. **Configure Parameters**: Set interest rates, LTV ratios, etc.
4. **Test Integration**: Perform end-to-end testing
5. **Document Addresses**: Record all contract addresses

## Deployment Checklist

- [ ] Environment variables configured
- [ ] Contracts compiled successfully
- [ ] Sufficient gas for deployment
- [ ] Contracts deployed
- [ ] Contracts verified on block explorer
- [ ] Protocol initialized
- [ ] Parameters configured
- [ ] Integration tests passed
- [ ] Documentation updated with addresses

## Troubleshooting

### Common Issues

1. **Out of Gas**: Increase gas limit
2. **Verification Fails**: Check constructor arguments
3. **RPC Errors**: Verify RPC URL and network connectivity
4. **Compilation Errors**: Check Solidity version compatibility

## Security Notes

⚠️ **Important**: 
- Never commit `.env` files
- Use separate wallets for testnet and mainnet
- Verify all contract addresses before use
- Test thoroughly on testnets before mainnet deployment

