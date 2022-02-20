import { Course } from './Course';
import { Invoice } from './Invoice';


export interface User {
    UserId: number; // this comes from localstorage uit de token so dont change
    hospital_id: number;
    Username: string;
    Token: string;
    role: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    image: string;
    lastActive: Date;
    photoUrl: string;
    city: string;
    mobile: string;
    email: string;
    country: string;
    worked_in: string;
    active: boolean;
    ltk: boolean;
    interests?: string;
    introduction?: string;
    lookingFor?: string;
    courses?: Course[];
    invoices?: Invoice[];
}
