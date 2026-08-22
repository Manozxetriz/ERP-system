import api from "./Api";

export interface RegisterRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  roleId: number;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export const register = async (data: RegisterRequest) => {
  const response = await api.post("/auth/register", data);

  return response.data;
};

export const login = async (data: LoginRequest) => {
  const response = await api.post("/auth/login", data);

  return response.data;
};