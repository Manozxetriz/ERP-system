import {  UserRound } from "lucide-react";
import { useNavigate } from "react-router-dom";

function Navbar() {
  const navigate = useNavigate();

  return (
    <nav className="sticky top-0 z-50 border-b border-neutral-200/70 bg-white/90 backdrop-blur-md">
      <div className="mx-auto flex h-16 max-w-7xl items-center justify-between px-6 lg:px-8">

        {/* Logo */}
        <button
          onClick={() => navigate("/")}
          className="group flex items-center gap-3"
        >
          {/* Logo mark */}
          <div className="flex h-9 w-9 items-center justify-center rounded-lg bg-neutral-900 text-white transition-transform duration-200 group-hover:scale-105">
            <svg
              width="20"
              height="20"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              strokeWidth="1.8"
            >
              <path
                d="M4 5h16M4 12h16M4 19h16"
                strokeLinecap="round"
              />
              <circle cx="8" cy="5" r="1.5" fill="currentColor" />
              <circle cx="15" cy="12" r="1.5" fill="currentColor" />
              <circle cx="10" cy="19" r="1.5" fill="currentColor" />
            </svg>
          </div>

          <div className="text-left">
            <div className="text-[15px] font-semibold tracking-tight text-neutral-900">
              Manufacturing
            </div>

            <div className="-mt-1 text-[10px] font-medium uppercase tracking-[0.18em] text-neutral-400">
              ERP
            </div>
          </div>
        </button>

        {/* Navigation */}
        <div className="hidden items-center gap-8 md:flex">
          <button className="text-sm font-medium text-neutral-600 transition-colors hover:text-neutral-950">
            Products
          </button>

          <button className="text-sm font-medium text-neutral-600 transition-colors hover:text-neutral-950">
            Solutions
          </button>

          <button className="text-sm font-medium text-neutral-600 transition-colors hover:text-neutral-950">
            Industries
          </button>

          <button className="text-sm font-medium text-neutral-600 transition-colors hover:text-neutral-950">
            About
          </button>
        </div>

        {/* Right side */}
        <div className="flex items-center gap-3">

          {/* Login */}
          <button
            onClick={() => navigate("/login")}
            className="flex items-center gap-2 rounded-full px-4 py-2 text-sm font-medium text-neutral-700 transition-all hover:bg-neutral-100 hover:text-neutral-950"
          >
            <UserRound size={17} strokeWidth={1.8} />
            <span>Login</span>
          </button>

         

        </div>
      </div>
    </nav>
  );
}

export default Navbar;