namespace Aud.IO.Algorithms

open System
open System.Numerics

module CooleyTukey =
    let splitArray array = Array.foldBack (fun x (l, r) -> x::r, l) array ([],[])

    let rec forwardComputations (amplitudes : Complex array) =
        let N = amplitudes.Length

        if N = 1 then
            amplitudes
        else
            let (even, odd) = splitArray(amplitudes)

            let evenArray = forwardComputations (even |> Array.ofList)
            let oddArray = forwardComputations (odd |> Array.ofList)

            for k in 0..(N/2-1) do
                let w = exp(Complex(0.0, -2.0 * Math.PI * float k) / Complex(float N, 0.0)) * oddArray.[k]
                amplitudes.[k] <- evenArray.[k] + w
                amplitudes.[N/2 + k] <- evenArray.[k] - w

            amplitudes


    let rec backwardComputations (frequency : Complex array, totalN : int) =
        let N = frequency.Length

        if N = 1 then
            frequency
        else
            let (even, odd) = splitArray(frequency)

            let evenArray = backwardComputations ((even |> Array.ofList), totalN)
            let oddArray = backwardComputations ((odd |> Array.ofList), totalN)

            for k in 0..(N/2-1) do
                let w = exp(Complex(0.0, 2.0 * Math.PI * float k) / Complex(float N, 0.0)) * oddArray.[k]
                frequency.[k] <- (evenArray.[k] + w) / Complex(float N, 0.0)
                frequency.[N/2 + k] <- (evenArray.[k] - w) / Complex(float N, 0.0)

            frequency
    

    let Forward (amplitudes : float array) =
        let N = amplitudes.Length
        let window k = Math.Sin(Math.PI * (float k + 0.5) / float N) ** 2.0
        //let window k = 1.0

        let X = [| for k in 0..(N-1) -> Complex(amplitudes.[k] * window(k), 0.0) |]
        forwardComputations X


    let Backward (frequencyBins : Complex array) =
        let N = frequencyBins.Length
        let X = backwardComputations (frequencyBins, N)
        
        let window k = (1.0 - Math.Sin(Math.PI * (float k + 0.5) / float N)) ** 2.0
        //let window k = 1.0

        [| for k in 0..(N-1) -> X.[k].Real * window(k) |]

