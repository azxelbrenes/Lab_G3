import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR PRODUCTOS
  obtenerProductos(): Observable<any> {
    return this.http.get(`${baseUrl}/Producto/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/Producto/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR PRODUCTO
  insertarProducto(producto: any): Observable<any> {
    return this.http.post(`${baseUrl}/Producto/Insertar`, producto).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR PRODUCTO
  actualizarProducto(producto: any): Observable<any> {
    return this.http.put(`${baseUrl}/Producto/Actualizar`, producto).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR PRODUCTO
  eliminarProducto(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/Producto/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('Error ProductoService:', error);
    return of(false);
  }
}