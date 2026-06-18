export interface Cliente {
  clienteId: number;
  nombre: string;
  email?: string;
  telefono?: string;
  fechaRegistro: string;
  activo: boolean;
  creadoEn: string;
  creadoPor?: string;
  actualizadoEn?: string;
  actualizadoPor?: string;
  tipoCedula: number;
}