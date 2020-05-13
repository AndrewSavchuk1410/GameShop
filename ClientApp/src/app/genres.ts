import { Games } from './games';

export class Genres {
    constructor(
        public id?: number,
        public name?: string,
        public info?: string,
        public games?: Games) { }
}