import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Genres } from './genres';
import { Games } from './games';
import { Publishers } from './publishers';
import { GamesPublishers } from './gamespublishers';

@Injectable()
export class DataService {

    private url = "/api/genres";

    constructor(private http: HttpClient) {
    }

    getGenres() {
        return this.http.get(this.url);
    }

    getGenre(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createGenre(genre: Genres) {
        return this.http.post(this.url, genre);
    }
    updateGenre(genre: Genres) {

        return this.http.put(this.url, genre);
    }
    deleteGenre(id: number) {
        return this.http.delete(this.url + '/' + id);
    }

    private url1 = "/api/games";

    getGames() {
        return this.http.get(this.url1);
    }

    getGame(id: number) {
        return this.http.get(this.url1 + '/' + id);
    }

    createGame(game: Games) {
        return this.http.post(this.url1, game);
    }
    updateGame(game: Games) {

        return this.http.put(this.url1, game);
    }
    deleteGame(id: number) {
        return this.http.delete(this.url1 + '/' + id);
    }
}