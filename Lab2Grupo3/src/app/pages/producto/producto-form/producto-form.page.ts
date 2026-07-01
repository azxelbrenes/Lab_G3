import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonToggle, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { ProductoService } from '../../../services/producto';

@Component({
  selector: 'app-producto-form',
  templateUrl: './producto-form.page.html',
  styleUrls: ['./producto-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonToggle, IonButton, IonButtons, IonBackButton
  ],
})
export class ProductoFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private productoService = inject(ProductoService);
  private toastCtrl = inject(ToastController);

  recordId: string | null = null;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    productoId: [{value: '', disabled: false}, [Validators.required]],
    nombre: ['', [Validators.required]],
    precio: [null as number | null, [Validators.required, Validators.min(0)]],
    stock: [null as number | null, [Validators.required, Validators.min(0)]],
    categoriaId: [null as number | null, [Validators.required, Validators.min(0)]],
    activo: [false, []],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.recordId = idParam;
      this.isEdit = true;
      this.form.get('productoId')?.disable();
      this.cargar(this.recordId);
    }
  }

  cargar(id: string): void {
    this.productoService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
          productoId: p.productoId,
          nombre: p.nombre,
          precio: p.precio,
          stock: p.stock,
          categoriaId: p.categoriaId,
          activo: p.activo,
          });
        }
      }
    });
  }

  async guardar(): Promise<void> {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.guardando = true;
    const payload = { ...this.form.getRawValue() };

    const request$ = this.isEdit
      ? this.productoService.actualizarProducto(payload)
      : this.productoService.insertarProducto(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Registro actualizado' : 'Registro creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/productos');
      },
      error: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: 'Ocurrió un error al guardar',
          duration: 2000,
          color: 'danger'
        });
        await toast.present();
      }
    });
  }
}
