import { GamesPublishers } from './gamespublishers';

export class Publishers {
    constructor(
        public id?: number,
        public name?: string,
        public info?: string,
        public gamespublishers?: GamesPublishers) { }
}