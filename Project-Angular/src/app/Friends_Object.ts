import { Friend } from './Friend';

export class Friends_Object{
    friends: Array<Friend>;
    
    constructor(public name: string, public components: Friend[]) {}
    
    [Symbol.iterator]() {
        let pointer = 0;
        let components = this.components;
    
        return {
          next(): IteratorResult<Friend> {
            if (pointer < components.length) {
              return {
                done: false,
                value: components[pointer++]
              }
            } else {
              return {
                done: true,
                value: null
              }
            }
          }
        }
      }
}