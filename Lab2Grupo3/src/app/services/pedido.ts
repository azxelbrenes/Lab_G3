import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR TODOS LOS PEDIDOS
  obtenerPedidos(): Observable<any> {
    return this.http.get(`${baseUrl}/Pedido/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/Pedido/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER PEDIDOS POR CLIENTE (muy común en laboratorios)
  obtenerPorCliente(clienteId: number): Observable<any> {
    return this.http.get(`${baseUrl}/Pedido/PorCliente/${clienteId}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR PEDIDO
  insertarPedido(pedido: any): Observable<any> {
    return this.http.post(`${baseUrl}/Pedido/Insertar`, pedido).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR PEDIDO
  actualizarPedido(pedido: any): Observable<any> {
    return this.http.put(`${baseUrl}/Pedido/Actualizar`, pedido).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR PEDIDO
  eliminarPedido(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/Pedido/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('Error PedidoService:', error);
    return of(false);
  }
}