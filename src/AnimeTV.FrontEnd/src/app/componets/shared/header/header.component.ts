import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  isSearchVisible = false;
  searchQuery = '';
  @ViewChild('searchInput') searchInput: any;

  toggleSearch() {
    this.isSearchVisible = !this.isSearchVisible;
    // Se o campo de pesquisa estiver visível, foca no input
    if (this.isSearchVisible) {
      setTimeout(() => {
        this.searchInput.focus();
      });
    }
  }

}
