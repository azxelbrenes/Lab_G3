import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonToggle, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { DetallePedidoService } from '../../../services/detalle-pedido';

@Component({
  selector: 'app-detalle-form',
  templateUrl: './detalle-form.page.html',
  styleUrls: ['./detalle-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonToggle, IonButton, IonButtons, IonBackButton
  ],
})
export class DetalleFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private detallePedidoService = inject(DetallePedidoService);
  private toastCtrl = inject(ToastController);

  recordId: number | null = null;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    pedidoId: [null as number | null, [Validators.required, Validators.min(0)]],
    productoId: ['', [Validators.required]],
    cantidad: [null as number | null, [Validators.required, Validators.min(0)]],
    precioUnitario: [null as number | null, [Validators.required, Validators.min(0)]],
    descuento: [null as number | null, []],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.recordId = Number(idParam);
      this.isEdit = true;
      this.form.get('detalleId')?.disable();
      this.cargar(this.recordId);
    }
  }

  cargar(id: number): void {
    this.detallePedidoService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
          pedidoId: p.pedidoId,
          productoId: p.productoId,
          cantidad: p.cantidad,
          precioUnitario: p.precioUnitario,
          descuento: p.descuento,
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
      ? this.detallePedidoService.actualizarDetalle(payload)
      : this.detallePedidoService.insertarDetalle(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Registro actualizado' : 'Registro creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/detalles-pedido');
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
