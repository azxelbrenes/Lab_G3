// Contrato genérico para las respuestas del back-end.
// No es una entidad (eso va en /models), es un "envoltorio" reutilizable.
export interface ApiResponse<T> {
  success: boolean;
  message?: string;
  data?: T;
}
