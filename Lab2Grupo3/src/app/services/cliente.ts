import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR CLIENTES
  obtenerClientes(): Observable<any> {
    return this.http.get(`${baseUrl}/Cliente/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/Cliente/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR CLIENTE
  insertarCliente(cliente: any): Observable<any> {
    return this.http.post(`${baseUrl}/Cliente/Insertar`, cliente).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR CLIENTE
  actualizarCliente(cliente: any): Observable<any> {
    return this.http.put(`${baseUrl}/Cliente/Actualizar`, cliente).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR CLIENTE
  eliminarCliente(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/Cliente/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('Error ClienteService:', error);
    return of(false);
  }
}