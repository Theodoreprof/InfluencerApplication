import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    gender: string;
    knownAs: string;
    created: Date;
    lastActive: Date;
    city: string;
    country: string;
    photoUrl: string;
    genres?: string;
    description?: string;
    influencerOrBrand?: string;
    photos?: Photo[];
    // instagramProfileLink?: string;
    // facebookProfileLink?: string;
    // youtubeChannelLink?: string;
    // twitterProfileLink?: string;
}
