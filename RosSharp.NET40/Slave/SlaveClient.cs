﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using RosSharp.Topic;

namespace RosSharp.Slave
{
    public class SlaveClient
    {
        private SlaveProxy _proxy;
        public SlaveClient(Uri uri)
        {
            _proxy = new SlaveProxy();
            _proxy.Url = uri.ToString();
        }

        public IObservable<object[]> GetBusStatsAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetBusStats, _proxy.EndGetBusStats)
                .Invoke(callerId)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); });
                
        }

        public IObservable<object[]> GetBusInfoAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetBusInfo, _proxy.EndGetBusInfo)
                .Invoke(callerId)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); });
        }

        public IObservable<Uri> GetMasterUriAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetMasterUri, _proxy.EndGetMasterUri)
                .Invoke(callerId)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => new Uri((string)ret[2]));
        }

        public IObservable<int> ShutdownAsync(string callerId, string msg)
        {
            return Observable.FromAsyncPattern<string, string, object[]>(_proxy.BeginShutdown, _proxy.EndShutdown)
                .Invoke(callerId, msg)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => (int)ret[2]);
        }

        public IObservable<int> GetPidAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetPid, _proxy.EndGetPid)
                .Invoke(callerId)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => (int)ret[2]);
        }

        public IObservable<List<TopicInfo>> GetSubscriptionsAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetSubscriptions,_proxy.EndGetSubscriptions)
                .Invoke(callerId)
                .Do(ret => { if ((int) ret[0] != 1) throw new InvalidOperationException((string) ret[1]); })
                .Select(ret => ((string[][]) ret[2])
                    .Select(x => new TopicInfo() { Name = (string)x[0], Type = (string)x[1] }).ToList());
        }

        public IObservable<List<TopicInfo>> GetPublicationsAsync(string callerId)
        {
            return Observable.FromAsyncPattern<string, object[]>(_proxy.BeginGetPublications,_proxy.EndGetPublications)
                .Invoke(callerId)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => ((object[])ret[2])
                    .Select(x => new TopicInfo() { Name = ((string[])x)[0], Type = ((string[])x)[1] }).ToList());
        }

        public IObservable<int> ParamUpdateAsync(string callerId, string parameterKey, object parameterValue)
        {
#if WINDOWS_PHONE
            return ObservableEx
#else
            return Observable
#endif
                .FromAsyncPattern<string, string, object, object[]>(_proxy.BeginParamUpdate, _proxy.EndParamUpdate)
                .Invoke(callerId,parameterKey,parameterValue)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => (int)ret[2]);
        }

        public IObservable<int> PublisherUpdateAsync(string callerId, string topic, string[] publishers)
        {
#if WINDOWS_PHONE
            return ObservableEx
#else
            return Observable
#endif
                .FromAsyncPattern<string, string, string[], object[]>(_proxy.BeginPublisherUpdate, _proxy.EndPublisherUpdate)
                .Invoke(callerId,topic,publishers)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => (int)ret[2]);
        }

        public IObservable<TopicParam> RequestTopicAsync(string callerId, string topic, object[] protocols)
        {
#if WINDOWS_PHONE
            return ObservableEx
#else
            return Observable
#endif
.FromAsyncPattern<string, string, object[], object[]>(_proxy.BeginRequestTopic, _proxy.EndRequestTopic)
                .Invoke(callerId, topic, protocols)
                .Do(ret => { if ((int)ret[0] != 1) throw new InvalidOperationException((string)ret[1]); })
                .Select(ret => new TopicParam
                {
                    ProtocolName = (string)((object[])ret[2])[0],
                    HostName = (string)((object[])ret[2])[1],
                    PortNumber = (int)((object[])ret[2])[2]
                });
        }
    }

    public class TopicParam
    {
        public string ProtocolName { get; set; }
        public string HostName { get; set; }
        public int PortNumber { get; set; }
    }

    public class TopicInfo : ITopic
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}