class vehicle{
    constructor(vehicleno,type,amount){

    this.vehicleno = vehicleno;
    this.type = type
    this.amount = amount
    this.date=date
}
}

 

class VehiclesManager{

    vehicle = [];

 

    getData(){

        if(localStorage.getItem("all") != undefined){

            this.vehicle = JSON.parse(localStorage.getItem("all"));

            debugger;

        }

    }

   

    addNewVehicle = (ex) => {

        this.getData();

        this.vehicle.push(ex);

        localStorage.setItem("all",JSON.stringify(this.vehicle));

    }

   

    getAllVehicle = () => {this.getData(); return this.vehicle};

 

   

 

    getStringDate(dt){

        return `${dt.getDate()}/${dt.getMonth()+1}/${dt.getFullYear()}`;

    }

    findExpenseByDate = (dt) => {

        this.getData();

        return this.vehicle.filter((s) => this.getStringDate(dt) == this.getStringDate(new Date(s.date)));

    }

 

 

    findExpenseBytype = (typ) => {

        this.getData();

        return this.vehicle.filter((d) => d.type == typ);

    }

 

   
}
