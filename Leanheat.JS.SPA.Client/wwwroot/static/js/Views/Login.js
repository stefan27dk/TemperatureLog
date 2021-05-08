// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor() {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Login");
    }



    // Get Html ====================================================>
    async getHtml() {
        return `
                     <div>LOGIN</div>     
  
                  `;
    }

}