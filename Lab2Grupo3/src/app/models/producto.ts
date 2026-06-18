export interface Producto {
  productoId: string;
  nombre: string;
  precio: number;
  stock: number;
  categoriaId: number;
  activo: boolean;
  creadoEn: string;
  creadoPor?: string;
  actualizadoEn?: string;
  actualizadoPor?: string;
}