import { Games } from './games';
import { Publishers } from './publishers';

export class GamesPublishers {
    constructor(
        public gameId?: number,
        public publisherId?: number,
        public id?: number,
        public games?: Games,
        public publishers?: Publishers) { }
}