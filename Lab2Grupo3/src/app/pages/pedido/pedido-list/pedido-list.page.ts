import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
  IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons,
  AlertController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { addOutline, createOutline, trashOutline } from 'ionicons/icons';

import { Pedido } from '../../../models/pedido';
import { PedidoService } from '../../../services/pedido';

@Component({
  selector: 'app-pedido-list',
  templateUrl: './pedido-list.page.html',
  styleUrls: ['./pedido-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class PedidoListPage implements OnInit {
  private pedidoService = inject(PedidoService);
  private alertCtrl = inject(AlertController);

  pedidos: Pedido[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargarPedidos();
  }

  cargarPedidos(): void {
    this.cargando = true;
    this.pedidoService.obtenerPedidos().subscribe({
      next: (resp) => {
        // Ajusta esta línea según lo que realmente devuelva tu API
        // (resp directamente, o resp.data si envuelves la respuesta)
        this.pedidos = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(pedido: Pedido): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: `¿Eliminar el pedido #${pedido.pedidoId}?`,
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.pedidoService.eliminarPedido(pedido.pedidoId).subscribe(() => {
              this.cargarPedidos();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
