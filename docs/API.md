# API Documentation

## Overview

This document provides API reference for the RWA-DeFi-Contract protocol interfaces.

## Core Interfaces

### IState

Base interface for protocol state management.

### IBorrowing

Interface for borrowing and loan management.

**Key Functions**:
- `borrow(uint256 tokenId, uint256 amount, uint256 months)`: Create a new loan
- `repay(uint256 tokenId, uint256 amount)`: Make a loan payment
- `liquidate(uint256 tokenId)`: Liquidate a defaulted loan

### IAuctions

Interface for property auction functionality.

**Key Functions**:
- `placeBid(uint256 tokenId, uint256 amount)`: Place a bid on a property
- `acceptBid(uint256 tokenId, uint256 bidIndex)`: Accept a bid and transfer property
- `cancelBid(uint256 tokenId, uint256 bidIndex)`: Cancel a placed bid

### IInfo

Interface for protocol information queries.

**Key Functions**:
- `getLoan(uint256 tokenId)`: Get loan information
- `getBids(uint256 tokenId)`: Get all bids for a property
- `residentToAddress(uint256 residentId)`: Get address for resident ID

### IResidents

Interface for resident management.

**Key Functions**:
- `verifyResident(address addr, uint256 residentId)`: Verify a resident
- `isResident(address addr)`: Check if address is a verified resident

### IPool

Interface for lending pool operations.

**Key Functions**:
- `supply(uint256 amount)`: Supply capital to the pool
- `withdraw(uint256 amount)`: Withdraw capital from the pool
- `getBalance(address user)`: Get user's pool balance

### IInterest

Interface for interest rate calculations.

**Key Functions**:
- `calculateRate(uint256 utilization)`: Calculate interest rate based on utilization
- `getCurrentRate()`: Get current interest rate

## Data Structures

### Loan

```solidity
struct Loan {
    uint256 principal;
    uint256 unpaidPrincipal;
    uint256 monthlyPayment;
    uint256 startTime;
    uint256 lastPaymentTime;
    UD60x18 ratePerSecond;
    uint256 months;
}
```

### Bid

```solidity
struct Bid {
    address bidder;
    uint256 amount;
    uint256 timestamp;
    bool active;
}
```

## Events

### Loan Events

- `LoanCreated(uint256 indexed tokenId, uint256 amount, uint256 months)`
- `PaymentMade(uint256 indexed tokenId, uint256 amount)`
- `LoanLiquidated(uint256 indexed tokenId)`

### Auction Events

- `BidPlaced(uint256 indexed tokenId, address indexed bidder, uint256 amount)`
- `BidAccepted(uint256 indexed tokenId, address indexed bidder, uint256 amount)`
- `BidCancelled(uint256 indexed tokenId, uint256 bidIndex)`

### Pool Events

- `CapitalSupplied(address indexed supplier, uint256 amount)`
- `CapitalWithdrawn(address indexed supplier, uint256 amount)`

## Error Codes

Common error messages:

- `"Not a resident"`: Address is not a verified resident
- `"Loan exists"`: Loan already exists for this property
- `"Insufficient funds"`: Insufficient funds for operation
- `"Invalid bid"`: Bid is invalid or expired
- `"Not authorized"`: Caller is not authorized for this operation

## Usage Examples

### Creating a Loan

```solidity
// Verify resident first
IResidents(protocol).verifyResident(userAddress, residentId);

// Mint property NFT
PropertyNft(propertyNft).mint(userAddress, metadata);

// Create loan
IBorrowing(protocol).borrow(tokenId, loanAmount, loanMonths);
```

### Placing a Bid

```solidity
// Place bid on property
IAuctions(protocol).placeBid(tokenId, bidAmount);

// Accept bid (if property owner)
IAuctions(protocol).acceptBid(tokenId, bidIndex);
```

### Supplying to Pool

```solidity
// Approve tokens
IERC20(underlying).approve(pool, amount);

// Supply capital
IPool(pool).supply(amount);
```

## Gas Estimates

Approximate gas costs (may vary):

- `borrow()`: ~200,000 gas
- `repay()`: ~100,000 gas
- `placeBid()`: ~80,000 gas
- `acceptBid()`: ~250,000 gas
- `supply()`: ~150,000 gas

## Security Considerations

- Always verify contract addresses before interaction
- Check return values from external calls
- Use reentrancy guards where appropriate
- Validate all inputs
- Handle errors gracefully

