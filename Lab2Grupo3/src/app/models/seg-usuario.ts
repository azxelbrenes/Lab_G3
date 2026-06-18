export interface SegUsuario {
  usuario: string;
  cedulaUsuario: string;
  tipoCedulaId: number;
  nombre: string;
  apellidos: string;
  direccion?: string;
  codigoPerfil: number;
  email?: string;
  telefono?: string;
  estado: number;
  fechaActualizacion: string;
}