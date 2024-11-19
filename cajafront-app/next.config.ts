import type { NextConfig } from "next";

const nextConfig: NextConfig = {
    env: {
      securityUrl: "http://localhost:8080",
      logicUrl: "http://localhost:8082"
    }
};

export default nextConfig;
