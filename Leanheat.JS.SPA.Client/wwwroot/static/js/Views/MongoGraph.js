// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor() {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("MongoGraph");
    }



    // Get Html ====================================================>
    async getHtml() {
        return `
                  <h1>Graph</h1>
                  <div class="container">
                      <iframe class="responsive-iframe" style="background: #21313C;border: none;border-radius: 2px;box-shadow: 0 2px 10px 0 rgba(70, 76, 79, .2);" width="640" height="480" src="https://charts.mongodb.com/charts-project-esbwm/embed/charts?id=ede2c842-c4c3-42ad-880d-7010f1437ad0&autoRefresh=300&theme=dark"></iframe>
                  </div>
                  <div class="container">
                      <iframe class="responsive-iframe" style="background: #21313C;border: none;border-radius: 2px;box-shadow: 0 2px 10px 0 rgba(70, 76, 79, .2);" width="640" height="480" src="https://charts.mongodb.com/charts-project-esbwm/embed/charts?id=c18240c5-d173-4b35-b871-b76b57d7c2a6&autoRefresh=3600&theme=dark"></iframe>  
                  </div>
          `;
    }


    // View Script ====================================================>
    async executeViewScript() {
    }

}