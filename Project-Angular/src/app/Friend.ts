class Lol{
    friend: string;
}
export class Friend{
    friends: Array<Lol>;
    
    constructor(public name: string, public components: Lol[]) {}
    
    [Symbol.iterator]() {
        let pointer = 0;
        let components = this.components;
    
        return {
          next(): IteratorResult<Lol> {
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