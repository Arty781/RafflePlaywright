﻿using Chilkat;

namespace PlaywrightRaffle.APIHelpers.Admin.UsersPage
{
    public class UsersRequest
    {
        private static string JsonBodyCreateuser()
        {
            CreateUserCmsRequest str = new()
            {
                Country = Country.COUNTRY_CODES[RandomHelper.RandomIntNumber(Country.COUNTRY_CODES.Count)],
                Name = Name.FirstName(),
                Surname = Name.LastName(),
                Phone = RandomHelper.RandomPhone(),
                Email = string.Concat("qatester-", DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"), "@putsbox.com"),
                IsBlocked = false
            };

            return JsonConvert.SerializeObject(str);
        }
        private static string JsonBodyGetUser(string email)
        {
            UsersRequestModel requestModel = new()
            {
                Filter = new Filter()
                {
                    Blocked = "All",
                    SearchName = "",
                    SearchEmail = email,
                    SearchPhone = "",
                    SearchSurname = ""
                },
                Pagination = new Pagination()
                {
                    Page = 1,
                    PerPage = 100000
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        private static string JsonBodyFilterUser(int pageCount, int usersCount)
        {
            var s = (pageCount / usersCount) * usersCount;
            var d = pageCount - s;
            UsersRequestModel requestModel = new()
            {
                Filter = new Filter()
                {
                    Blocked = "All",
                    SearchName = "",
                    SearchEmail = "",
                    SearchPhone = "",
                    SearchSurname = ""
                },
                Pagination = new Pagination()
                {
                    Page = pageCount / usersCount,
                    PerPage = usersCount + d
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        private static string JsonBodyGetUserOrders()
        {
            UserOrdersRequestModel requestModel = new()
            {
                Filter = new FilterUserOrders()
                {
                    SearchField = "",
                    SearchString = "",
                    StartDate = DateTime.Now.AddYears(-5).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                    EndDate = DateTime.Now.AddYears(5).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                    Competitions = new List<object>() { }
                },
                Pagination = new Pagination()
                {
                    Page = 1,
                    PerPage = 10
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        private static string JsonBodyAddRaffle(string prizeId)
        {
            AddTicketsRequestModel requestModel = new()
            {
                Competition = "raffle",
                PrizeId = prizeId,
                TicketsCount = RandomHelper.RandomIntNumber(100)
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        private static string JsonBodyRemovetickets(OrdersResponseModel ordersIds)
        {
            DeleteOrdersRequestModel requestModel = new()
            {
                Ids = ordersIds.Orders.FirstOrDefault().OrdersIds
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        private static string JsonBodyAddCredits(string time, int i)
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateTomorrow = DateTime.Now.AddDays(1);
            AddCreditsRequestModel requestModel = new();
            if (time.ToLower() == "now")
            {
                string createDateOneDay = dateNow.AddDays(-30 + 1).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateThreeDays = dateNow.AddDays(-30 + 3).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateSevenDays = dateNow.AddDays(-30 + 7).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                if (i == 0)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateOneDay,
                        ExpiredDate = DateTime.Parse(createDateOneDay).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 1)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateThreeDays,
                        ExpiredDate = DateTime.Parse(createDateThreeDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 2)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateSevenDays,
                        ExpiredDate = DateTime.Parse(createDateSevenDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }

            }
            else if (time.ToLower() == "tomorrow")
            {
                string createDateOneDay = dateTomorrow.AddDays(-30 + 1).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateThreeDays = dateTomorrow.AddDays(-30 + 3).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateSevenDays = dateTomorrow.AddDays(-30 + 7).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                if (i == 0)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateOneDay,
                        ExpiredDate = DateTime.Parse(createDateOneDay).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 1)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateThreeDays,
                        ExpiredDate = DateTime.Parse(createDateThreeDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 2)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateSevenDays,
                        ExpiredDate = DateTime.Parse(createDateSevenDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }

            }

            return JsonConvert.SerializeObject(requestModel);
        }

        public static CreateUserResponse CreateUserOnCms(SignInResponseModelAdmin token)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/cms",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyCreateuser(), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var response = JsonConvert.DeserializeObject<CreateUserResponse?>(resp.BodyStr) ?? throw new Exception("Response body is null.");
            return response;
        }
        public static UsersResponse? GetUser(SignInResponseModelAdmin token, string email)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyGetUser(email), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var response = JsonConvert.DeserializeObject<UsersResponse?>(resp.BodyStr);
            return response;
        }

        public static UsersResponse? GetLastUsers(SignInResponseModelAdmin token, int usersCount)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyFilterUser(110, 10), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var response = JsonConvert.DeserializeObject<UsersResponse>(resp.BodyStr);

            req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyFilterUser(response.AllCount, usersCount), charset: "utf-8");

            http = new();

            resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            response = JsonConvert.DeserializeObject<UsersResponse?>(resp.BodyStr);
            return response;
        }

        public static OrdersResponseModel? GetUserOrders(SignInResponseModelAdmin token, string userId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"/api/users/{userId}/orders/admin",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyGetUserOrders(), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<OrdersResponseModel?>(resp.BodyStr);

            return response;
        }

        public static AddTicketsResponseModel? AddDreamhomeTicketsToUser(SignInResponseModelAdmin token, string userId, string prizeId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "PATCH",
                Path = $"/api/users/{userId}/add-tickets",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyAddRaffle(prizeId), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<AddTicketsResponseModel?>(resp.BodyStr);
            return response;
        }

        public static AddCreditsResponseModel? AddCreditsToUser(SignInResponseModelAdmin token, string userId, string nowOrTomorrow)
        {
            AddCreditsResponseModel? response = null;
            for (int i = 0; i < 3; i++)
            {
                HttpRequest req = new()
                {
                    HttpVerb = "PATCH",
                    Path = $"/api/credits/{userId}",
                    ContentType = "application/json"
                };
                req.AddHeader("Connection", "Keep-Alive");
                req.AddHeader("applicationid", "WppJsNsSvr");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("authorization", $"Bearer {token.Token}");
                req.LoadBodyFromString(JsonBodyAddCredits(nowOrTomorrow, i), charset: "utf-8");
                Http http = new();
                HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
                if (http.LastMethodSuccess != true)
                {
                    throw new ArgumentException(http.LastErrorText);
                }
                Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
                response = JsonConvert.DeserializeObject<AddCreditsResponseModel?>(resp.BodyStr);
            }
            return response;
        }

        public static void RemoveTicketsFromUser(SignInResponseModelAdmin token, OrdersResponseModel ordersIds)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"/api/orders/delete-many/admin",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyRemovetickets(ordersIds), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
        }

        public static void DeleteLastUser(SignInResponseModelAdmin token, UsersResponse user)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"api/users/{user.Users.FirstOrDefault().Id}",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            Http http = new();
            _ = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

        }

        public static void DeleteUser(SignInResponseModelAdmin token, string userId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"api/users/{userId}",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            Http http = new();
            _ = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

        }
    }
}
