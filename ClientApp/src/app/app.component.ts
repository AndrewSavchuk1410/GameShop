import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Genres } from './genres';
import { Games } from './games';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    mode: number = 1; 

    changeMode(newMode: number) {
        this.mode = newMode;
    }

    genre: Genres = new Genres();   // изменяемый товар
    genres: Genres[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadGenres();    // загрузка данных при старте компонента
        this.loadGames();
    }
    // получаем данные через сервис
    loadGenres() {
        this.dataService.getGenres()
            .subscribe((data: Genres[]) => this.genres = data);
    }
    // сохранение данных
    save() {
        if (this.genre.id == null) {
            this.dataService.createGenre(this.genre)
                .subscribe((data: Genres) => this.genres.push(data));
        } else {
            this.dataService.updateGenre(this.genre)
                .subscribe(data => this.loadGenres());
        }
        this.cancel();
    }
    editGenre(g: Genres) {
        this.genre = g;
    }
    cancel() {
        this.genre = new Genres();
        this.tableMode = true;
    }
    delete(g: Genres) {
        this.dataService.deleteGenre(g.id)
            .subscribe(data => this.loadGenres());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }

    game: Games = new Games();   // изменяемый товар
    games: Games[];                // массив товаров
    tableMode1: boolean = true;          // табличный режим

    // получаем данные через сервис
    loadGames() {
        this.dataService.getGames()
            .subscribe((data: Games[]) => this.games = data);
    }
    // сохранение данных
    save1() {
        if (this.game.id == null) {
            this.dataService.createGame(this.game)
                .subscribe((data: Games) => this.games.push(data));
        } else {
            this.dataService.updateGame(this.game)
                .subscribe(data => this.loadGames());
        }
        this.cancel1();
    }
    editGame(g: Games) {
        this.game = g;
    }
    cancel1() {
        this.game = new Games();
        this.tableMode1 = true;
    }
    delete1(g: Games) {
        this.dataService.deleteGame(g.id)
            .subscribe(data => this.loadGames());
    }
    add1() {
        this.cancel1();
        this.tableMode1 = false;
    }

    findGameGenre(gg: Games) {
        for (let g of this.genres) {
            if (gg.genresId == g.id) {
                return g.name;
            }
        }
        return "";
    }
}