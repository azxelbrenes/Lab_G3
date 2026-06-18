import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class TipoCedulaService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR TIPOS DE CÉDULA
  obtenerTiposCedula(): Observable<any> {
    return this.http.get(`${baseUrl}/TipoCedula/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/TipoCedula/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 INSERTAR
  insertarTipoCedula(tipo: any): Observable<any> {
    return this.http.post(`${baseUrl}/TipoCedula/Insertar`, tipo).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR
  actualizarTipoCedula(tipo: any): Observable<any> {
    return this.http.put(`${baseUrl}/TipoCedula/Actualizar`, tipo).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR
  eliminarTipoCedula(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/TipoCedula/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('TipoCedulaService error:', error);
    return of(false);
  }
}