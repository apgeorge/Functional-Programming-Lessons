#light
//http://blogs.msdn.com/andrewkennedy/archive/2008/09/02/units-of-measure-in-f-part-two-unit-conversions.aspx

[<Measure>] type kg
[<Measure>] type m
[<Measure>] type s

let g = 9.8<m/s^2>
let g1 = 9.8<m s^-2>
let g2 = 9.8<m/s/s>
let h = 10.0<m>

let v = sqrt ( 2.0 * g * h)
//let v = sqrt ( 2.0 * g + h)

let m = 65.0<kg>
let f = m * g

[<Measure>]type N = kg m/s^2


open Microsoft.FSharp.Math
open SI

let g3 = 9.8<m/s^2>

let g4 = PhysicalConstants.G;

[<Measure>]type ft

let feetPerm =  3.28084<ft/m>

[<Measure>]type ft1 = 
            static member perM = 3.28084<ft/m>
            
let t = 5.0 * 1.0<m>

let sqr (x:float<_>) =  x * x

let cube x = x * sqr x

// pretty cool type inference
let ff x y = sqr x + cube y

type Complex = { re:float; im:float; }

type Complex1< [<Measure>] 'u> = { re:float<'u>; im:float<'u> }





