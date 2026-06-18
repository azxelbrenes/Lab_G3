import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class DetallePedidoService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR TODOS LOS DETALLES
  obtenerDetalles(): Observable<any> {
    return this.http.get(`${baseUrl}/DetallePedido/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/DetallePedido/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER DETALLES POR PEDIDO (MUY IMPORTANTE)
  obtenerPorPedido(pedidoId: number): Observable<any> {
    return this.http.get(`${baseUrl}/DetallePedido/PorPedido/${pedidoId}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR DETALLE
  insertarDetalle(detalle: any): Observable<any> {
    return this.http.post(`${baseUrl}/DetallePedido/Insertar`, detalle).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR DETALLE
  actualizarDetalle(detalle: any): Observable<any> {
    return this.http.put(`${baseUrl}/DetallePedido/Actualizar`, detalle).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR DETALLE
  eliminarDetalle(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/DetallePedido/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 ERROR HANDLER
  private handleError(error: any) {
    console.error('Error DetallePedidoService:', error);
    return of(false);
  }
}