import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class CategoriumService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR TODAS LAS CATEGORÍAS
  obtenerCategorias(): Observable<any> {
    return this.http.get(`${baseUrl}/Categorium/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/Categorium/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR
  insertarCategoria(categoria: any): Observable<any> {
    return this.http.post(`${baseUrl}/Categorium/Insertar`, categoria).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR
  actualizarCategoria(categoria: any): Observable<any> {
    return this.http.put(`${baseUrl}/Categorium/Actualizar`, categoria).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR
  eliminarCategoria(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/Categorium/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('Error en CategoriumService:', error);
    return of(false);
  }
}