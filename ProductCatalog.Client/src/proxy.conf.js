const PROXY_CONFIG = [
  {
    context: [
      "/products",
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
