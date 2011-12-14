module statics
//Jomo Fisher—a theme in the design of the F# language is that problems in the code are revealed as compilation errors
type Courtesy = Mr | Ms | Dr 

type Customer = {
    Courtesy:Courtesy
    Name:string
}

type Letter = {
    Introduction:string
    Body:string
}

let Correspond(customer,message) = 
    match customer.Courtesy with
    | Mr -> {Introduction = "Mr. " + customer.Name; Body=message}
    | Ms -> {Introduction = "Ms. " + customer.Name; Body=message}
//    | _ -> null
    
    
//F# objects are not allowed to be null and,