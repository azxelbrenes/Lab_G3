export interface Pedido {
  pedidoId: number;
  clienteId: number;
  fechaPedido: string;
  moneda: string;
  total?: number;
  creadoEn: string;
  creadoPor?: string;
  actualizadoEn?: string;
  actualizadoPor?: string;
}