export interface DetallePedido {
  detalleId: number;
  pedidoId: number;
  productoId: string;
  cantidad: number;
  precioUnitario: number;
  descuento: number;
}