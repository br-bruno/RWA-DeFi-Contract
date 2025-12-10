# Architecture Documentation

## Overview

The RWA-DeFi-Contract protocol is built using a modular, upgradeable architecture that separates concerns and enables flexible upgrades while maintaining state consistency.

## Core Design Principles

1. **Upgradeability**: Proxy pattern enables contract upgrades without losing state
2. **Modularity**: Separate contracts for different functionalities
3. **Gas Efficiency**: Optimized for on-chain operations
4. **Security**: Multiple layers of access control and validation

## System Architecture

### Proxy Pattern

The protocol uses a custom proxy implementation (`ProtocolProxy.sol`) that:

- Maps function selectors to implementation contracts
- Maintains state in a single storage contract (`State.sol`)
- Enables upgrades without storage collisions
- Supports delegatecall for logic execution

### State Management

All protocol state is stored in `State.sol`, which is inherited by:

- The proxy contract
- All logic implementation contracts

This ensures:
- No storage collisions during upgrades
- Consistent state access across implementations
- Clear state variable organization

### Contract Hierarchy

```
ProtocolProxy (Proxy)
    └── State (Storage)
        ├── TargetManager (Upgrade Logic)
        ├── Auctions (Auction Logic)
        ├── Borrowing (Borrowing Logic)
        ├── LoanStatus (Loan Management)
        └── Interest Models (Interest Calculation)
```

## Component Details

### State Contract

**Purpose**: Centralized state storage

**Key State Variables**:
- `UNDERLYING`: ERC20 token used for lending
- `PROPERTY`: Property NFT contract
- `pool`: Lending pool contract
- `_addressToResident`: Mapping of addresses to resident IDs
- `_loans`: Mapping of token IDs to loan data
- `_bids`: Mapping of token IDs to bid arrays

### Target Manager

**Purpose**: Handles upgrade and delegatecall logic

**Responsibilities**:
- Function selector routing
- Implementation contract management
- Upgrade authorization

### Interest Models

Three interest rate models are supported:

1. **Constant Rate** (`InterestConstant.sol`)
   - Fixed interest rate
   - Simple calculation

2. **Two-Slope Model** (`Interest2Slopes.sol`)
   - Variable rate based on utilization
   - Two distinct slopes for different utilization ranges

3. **Smooth Curve Model** (`InterestCurve.sol`)
   - Continuous rate curve
   - Smooth transitions

### Loan Management

**Amortization** (`Amortization.sol`):
- Gas-efficient amortization calculations
- Flexible payment schedules
- Interest accrual tracking

**Loan Status** (`LoanStatus.sol`):
- Active loan tracking
- Default detection
- Payment processing

### Auction System

**Purpose**: Enable property sales with mortgage payoff

**Features**:
- Multiple bids per property
- Automatic mortgage payoff
- Remaining proceeds to seller

## Data Flow

### Lending Flow

1. Lender supplies capital to pool
2. Pool mints interest-bearing tokens
3. Capital available for mortgages

### Borrowing Flow

1. Resident verified
2. Property NFT minted
3. Loan application submitted
4. Loan approved and funded
5. Amortization schedule created

### Auction Flow

1. Property owner receives bid
2. Bid validated
3. Mortgage debt calculated
4. Property transferred
5. Mortgage paid off
6. Remaining proceeds to seller

## Security Considerations

### Access Control

- Resident verification required for borrowing
- Role-based access for protocol functions
- Multisig for critical operations

### Reentrancy Protection

- Checks-Effects-Interactions pattern
- External call protection

### Upgrade Safety

- Storage collision prevention
- Function selector validation
- Upgrade authorization checks

## Gas Optimization

### Strategies Used

1. **Packed Storage**: Efficient state variable packing
2. **Event Optimization**: Minimal event data
3. **Batch Operations**: Group related operations
4. **Efficient Math**: Fixed-point arithmetic for interest

## Future Enhancements

- [ ] Additional interest rate models
- [ ] Cross-chain support
- [ ] Advanced auction mechanisms
- [ ] Insurance integration
- [ ] Governance token

