# NeshanApi.Dotnet

This library is wrapper to help to use neshan.org in dotnet. all api neshan provide is suported. you can get more
information in this <a href="https://platform.neshan.org/api/getting-started">link</a>

## Installation

You can install it from nuget with this command
<br>

`Install-Package NeshanApi.Dotnet`

Or with dotnet cli with
<br>

`dotnet add package NeshanApi.Dotnet`

## Usage

Before to start use this you must get your <b>API KEY</b> from <a href="https://platform.neshan.org/">Neshan
Platform</a>, then you can start.
<br>
for configure your client you must use <b>NeshanConfig</b> class and pass to client instance. the only config currently
available is <b>API KEY</b>.
<br>
After done all of this you can create a instance of **NeshanApiClient**. to do that you have 2 option

1. Create directly
   <br>
   this is example how you can create your instance
   <br>

<pre>
<code>
public static INeshanApiClient GetInstance()
{
   return new NeshanApiClient(new HttpClient(), new NeshanConfig()
   {
        ApiKey = Constants.ApiKey
   });
}
</code>
</pre>

2. With DI Container
   <br> if you want use dependency injection you can register **NeshanApiClient** as **INeshanApiClient**.
   <br> for example if you use this in <b>Asp.net Core</b> you registerd as typed client like below

<pre>
<code>
services.AddHttpClient&#x0003CINeshanApiService, NeshanApiService&#x0003E();
</code>
</pre>

## Methods

Client has 8 method for 7 api:

1. <b>Direction & DirectionWithOutTraffic</b> methods are for <b>Routing
   API</b> (<a href="https://platform.neshan.org/api/direction">Doc link</a>)
2. <b>LocationBasedSearch</b> method is for Search API (<a href="https://platform.neshan.org/api/search">Doc link</a>)
3. <b>TravelingSalesmanProblem</b> method is for Traveling Salesman Problem
   API (<a href="https://platform.neshan.org/api/tsp">Doc link</a>)
4. <b>ReverseGeocoding</b> method is for Reverse Geocoding
   API (<a href="https://platform.neshan.org/api/reverse-geocoding">Doc link</a>)
5. <b>Geocoding</b> method is for Geocoding API (<a href="https://platform.neshan.org/api/geocoding">Doc link</a>)
6. <b>DistanceMatrix</b> method is for Distance Matrix API (<a href="https://platform.neshan.org/api/distance-matrix">
   Doc link</a>)
7. <b>MapMatching</b> method is for Map Matching API (<a href="https://platform.neshan.org/api/map-matching">Doc
   link</a>)

## Exception

There are 2 types of <b>Exception</b> in this library.

1. Neshan Api Error
   <br>
   these exceptions are neshan api error such as 470(CoordinateParseError) status code. when response status code set
   470, NeshanCoordinateParseException will rise.
   <br>
   <br>
   Exceptions:<br>
    - 470: NeshanCoordinateParseException
    - 480: NeshanKeyNotFoundException
    - 481: NeshanLimitExceededException
    - 482: NeshanRateExceededException
    - 483: NeshanApiKeyTypeErrorException
    - 484: NeshanApiWhiteListErrorException
    - 485: NeshanApiServiceListErrorException
      <br>
      <br>
2. Internal Exceptions
   <br>
   these exceptions are rise when response status code are 200 but a error happened.
   <br>
   <br>
   Exceptions:<br>
    - NeshanNoResultException: this is happened in Geocoding API 
    - NeshanNoRouteFoundException: this is happened in Routing API
      <br>
      <br>