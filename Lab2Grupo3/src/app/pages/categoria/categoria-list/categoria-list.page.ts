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

import { Categorium } from '../../../models/categorium';
import { CategoriumService } from '../../../services/categorium';

@Component({
  selector: 'app-categoria-list',
  templateUrl: './categoria-list.page.html',
  styleUrls: ['./categoria-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class CategoriaListPage implements OnInit {
  private categoriumService = inject(CategoriumService);
  private alertCtrl = inject(AlertController);

  categorias: Categorium[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargar();
  }

  cargar(): void {
    this.cargando = true;
    this.categoriumService.obtenerCategorias().subscribe({
      next: (resp) => {
        this.categorias = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(item: Categorium): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: '¿Eliminar este registro?',
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.categoriumService.eliminarCategoria(item.categoriaId).subscribe(() => {
              this.cargar();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
