export type Person = {
    personId: number;
    name: string; 
    age: number; 
    nick: string; 
    date: string; 
}

export type PersonCreate = {
    name: string;
    age: number;
    nick: string;
    date: string;
}