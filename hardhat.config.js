require('hardhat-contract-sizer');
require("@nomiclabs/hardhat-waffle");
require('dotenv').config();

/** @type import('hardhat/config').HardhatUserConfig */
module.exports = {
  solidity: "0.8.19",
  networks: {
    hardhat: {
      forking: {
        url: process.env.MAINNET_RPC_URL || "https://mainnet.infura.io/v3/YOUR_INFURA_KEY"
      }
    },
    polygonMumbai: {
      url: process.env.POLYGON_MUMBAI_RPC_URL || "https://polygon-mumbai.g.alchemy.com/v2/YOUR_ALCHEMY_KEY",
      accounts: {
        mnemonic: process.env.MNEMONIC || "",
        path: "m/44'/60'/0'/0",
        initialIndex: 0,
        count: 20,
        passphrase: "",
      }
    },
    sepolia: {
      url: process.env.SEPOLIA_RPC_URL || "https://eth-sepolia.g.alchemy.com/v2/YOUR_ALCHEMY_KEY",
      accounts: {
        mnemonic: process.env.MNEMONIC || "",
        path: "m/44'/60'/0'/0",
        initialIndex: 0,
        count: 20,
        passphrase: "",
      }
    }
  },
  contractSizer: {
    runOnCompile: true
  }
};