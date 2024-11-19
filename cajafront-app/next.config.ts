import type { NextConfig } from "next";

const nextConfig: NextConfig = {
    env: {
      securityUrl: "http://localhost:5194"
    }
};

export default nextConfig;
