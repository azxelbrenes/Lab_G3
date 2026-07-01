import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { PedidoService } from '../../../services/pedido';

@Component({
  selector: 'app-pedido-form',
  templateUrl: './pedido-form.page.html',
  styleUrls: ['./pedido-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonButton, IonButtons, IonBackButton
  ],
})
export class PedidoFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private pedidoService = inject(PedidoService);
  private toastCtrl = inject(ToastController);

  // pedidoId != 0 => modo edición
  pedidoId = 0;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    clienteId: [null as number | null, [Validators.required]],
    fechaPedido: ['', [Validators.required]],
    moneda: ['CRC', [Validators.required]],
    total: [0, [Validators.required, Validators.min(0)]],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.pedidoId = Number(idParam);
      this.isEdit = true;
      this.cargarPedido(this.pedidoId);
    }
  }

  cargarPedido(id: number): void {
    this.pedidoService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
            clienteId: p.clienteId,
            fechaPedido: p.fechaPedido,
            moneda: p.moneda,
            total: p.total,
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
    const payload = { ...this.form.value, pedidoId: this.pedidoId };

    const request$ = this.isEdit
      ? this.pedidoService.actualizarPedido(payload)
      : this.pedidoService.insertarPedido(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Pedido actualizado' : 'Pedido creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/pedidos');
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
