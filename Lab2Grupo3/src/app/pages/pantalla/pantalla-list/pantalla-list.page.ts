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

import { SegPantalla } from '../../../models/seg-pantalla';
import { SegPantallaService } from '../../../services/seg-pantalla';

@Component({
  selector: 'app-pantalla-list',
  templateUrl: './pantalla-list.page.html',
  styleUrls: ['./pantalla-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class PantallaListPage implements OnInit {
  private segPantallaService = inject(SegPantallaService);
  private alertCtrl = inject(AlertController);

  pantallas: SegPantalla[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargar();
  }

  cargar(): void {
    this.cargando = true;
    this.segPantallaService.obtenerPantallas().subscribe({
      next: (resp) => {
        this.pantallas = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(item: SegPantalla): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: '¿Eliminar este registro?',
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.segPantallaService.eliminarPantalla(item.codigoPantalla).subscribe(() => {
              this.cargar();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
