using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectAI.ProjectAlgorithm
{
    internal class SearchAlgorithmString
    {
        public SearchAlgorithmString()
        {
        }

        /// <summary>
        /// 등록 함수
        /// </summary>
        /// <param name="searchKeys"> 대상 array </param>
        /// <param name="searchDatas"> 검색할 데이터 array </param>
        /// <param name="cancellationToken"> 중지 토큰 </param>
        /// <returns> 검색된 array, 대상 array와 같은 index 값 </returns>
        internal async Task<string[]> StringArraySearchManager(string[] searchKeys, string[] searchDatas, CancellationToken cancellationToken)
        {
            int taskNumber = 8;


            List<string> searchList = new List<string>();

            if (searchKeys.Length > 1000 && searchDatas.Length > 1000)
            {

            }
            else // 작엽량이 적은 경우
            {
                taskNumber = 2;
            }

            int arraySliceBand = searchKeys.Length / taskNumber;
            List<string[]> searchKeyList = new List<string[]>();

            for (int i = 0; i < taskNumber - 1; i++)
                searchKeyList.Add(new ArraySegment<string>(searchKeys, i * arraySliceBand, arraySliceBand).ToArray());
            searchKeyList.Add(new ArraySegment<string>(searchKeys, (taskNumber - 1) * arraySliceBand, searchKeys.Length - ((taskNumber - 1) * arraySliceBand)).ToArray());

            Task<string[]>[] tasks = new Task<string[]>[taskNumber];

            for (int i = 0; i < tasks.Length; i++)
            {
                //tasks[i] = StringArraySearch(searchKeyList[i], searchDatas, i, arraySliceBand, cancellationToken);
                Thread.Sleep(10);
                tasks[i] = Task.Run(() => StringArraySearch(searchKeyList[i], searchDatas, i, arraySliceBand, cancellationToken));
                Thread.Sleep(10);
            }
            for (int i = 0; i < tasks.Length; i++)
            {
                await tasks[i];
            }
            for (int i = 0; i < tasks.Length; i++)
            {
                searchList.AddRange(await tasks[i]);
            }
            return searchList.ToArray();
        }

        private async Task<string[]> StringArraySearch(string[] searchKeys, string[] searchDatas, int taskNumber, int arraySliceBand, CancellationToken cancellationToken)
        {
            List<string> fileNameList = new List<string>();
            Task<string> tasks;

            for (int i = 0; i < searchKeys.Length; i++)
            {
                try
                {
                    if (cancellationToken.IsCancellationRequested)
                        return null;

                    tasks = StringSearchManager(searchKeys[i], (taskNumber * arraySliceBand) + i, searchDatas, cancellationToken, taskNumber);
                    tasks.Wait();
                    string res = await tasks;
                    //Console.WriteLine(res);
                    fileNameList.Add(res);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("ERROR Task Number" + taskNumber.ToString());
                    //Console.WriteLine(ex);
                    //string mess = $"Run Task Number: {taskNumber}, " + "Algorithm used Fail, " + "";
                    fileNameList.Add(null);
                }
                finally
                {

                }
            }
            return fileNameList.ToArray();
        }

        internal async Task<string> StringSearchManager(string searchKey, int searchKeyIndex, string[] searchDatas, CancellationToken cancellationToken, int upTaskNumber = -1)
        {
            string matchedValue = null;
            int searchIndexBand = 100;

            List<string[]> arraySegment = new List<string[]>();
            List<Task<string>> tasks = new List<Task<string>>();
            //Task<string>[] tasks = new Task<string>[4];

            if (searchKeyIndex < searchIndexBand)
            {
                if (searchDatas[searchKeyIndex].Contains(searchKey))
                {
                    //GC.EndNoGCRegion();
                    return searchDatas[searchKeyIndex];
                }
                else
                {
                    //GC.EndNoGCRegion();
                    return await this.StringSearch(searchKey, searchDatas, cancellationToken);
                }
            }
            else if (searchDatas.Length < searchKeyIndex || searchKeyIndex < searchIndexBand)
            {
                CancellationTokenSource cancellationTokenSources = new CancellationTokenSource();
                int taskNumber = 4;
                int arraySliceBand = searchDatas.Length / taskNumber;
                for (int i = 0; i < taskNumber - 1; i++)
                    arraySegment.Add(new ArraySegment<string>(searchDatas, i * arraySliceBand, arraySliceBand).ToArray());
                arraySegment.Add(new ArraySegment<string>(searchDatas, (taskNumber - 1) * arraySliceBand, searchDatas.Length - ((taskNumber - 1) * arraySliceBand)).ToArray());

                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[0], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[1], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[2], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[3], cancellationTokenSources.Token)));

                while (true)
                {
                    //await tasks[0];
                    if (await tasks[0] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used: 0, " + await tasks[0];
                        return await tasks[0];
                    }
                    //await tasks[1];
                    if (await tasks[1] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 1, " + await tasks[1];
                        return await tasks[1];
                    }
                    //await tasks[2];
                    if (await tasks[2] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 2, " + await tasks[2];
                        return await tasks[2];
                    }
                    //await tasks[3];
                    if (await tasks[3] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 3, " + await tasks[3];
                        return await tasks[3];
                    }
                }
            }
            else if (searchDatas.Length - searchKeyIndex < searchIndexBand)
            {
                CancellationTokenSource cancellationTokenSources = new CancellationTokenSource();

                arraySegment.Add(new ArraySegment<string>(searchDatas, searchKeyIndex, searchDatas.Length - searchKeyIndex).ToArray());
                arraySegment.Add(new ArraySegment<string>(searchDatas, searchKeyIndex - searchIndexBand, searchIndexBand).ToArray());
                arraySegment.Add(new ArraySegment<string>(searchDatas, 0, searchKeyIndex - searchIndexBand).ToArray());

                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[0], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[1], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[2], cancellationTokenSources.Token)));

                await tasks[0];
                if (await tasks[0] != null)
                {
                    cancellationTokenSources.Cancel();
                    //GC.EndNoGCRegion();
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm used: 0, " + await tasks[0];
                    return await tasks[0];
                }
                await tasks[1];
                if (await tasks[1] != null)
                {
                    cancellationTokenSources.Cancel();
                    //GC.EndNoGCRegion();
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 1, " + await tasks[1];
                    return await tasks[1];
                }
                await tasks[2];
                if (await tasks[2] != null)
                {
                    cancellationTokenSources.Cancel();
                    //GC.EndNoGCRegion();
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 2, " + await tasks[2];
                    return await tasks[2];
                }
                return null;
            }
            else
            {
                //Task<string>[] tasks = new Task<string>[4];
                CancellationTokenSource cancellationTokenSources = new CancellationTokenSource();

                if (cancellationToken.IsCancellationRequested)
                    return null;

                //Task<string>[] tasks = new Task<string>[4];

                try
                {
                    // 그전 버전
                    arraySegment.Add(new ArraySegment<string>(searchDatas, searchKeyIndex, searchIndexBand).ToArray());
                    arraySegment.Add(new ArraySegment<string>(searchDatas, searchKeyIndex - searchIndexBand, searchIndexBand).ToArray());
                    arraySegment.Add(new ArraySegment<string>(searchDatas, 0, searchKeyIndex - searchIndexBand).ToArray());
                    arraySegment.Add(new ArraySegment<string>(searchDatas, searchKeyIndex + searchIndexBand, searchDatas.Length - (searchKeyIndex + searchIndexBand)).ToArray());

                    // C# 3.0 이상
                    //arraySegment.Add(searchDatas[searchKeyIndex..(searchKeyIndex + searchIndexBand)]);
                    //arraySegment.Add(searchDatas[(searchKeyIndex - searchIndexBand)..searchKeyIndex]);
                    //arraySegment.Add(searchDatas[0..(searchKeyIndex - searchIndexBand)]);
                    //arraySegment.Add(searchDatas[(searchKeyIndex + searchIndexBand)..(searchDatas.Length)]);
                }
                catch (Exception ex)
                {
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm Error, " + searchKey;
                }

                //tasks[0] = Task.Run(() => this.StringSearch(searchKey, s0, cancellationTokenSources.Token));
                //tasks[1] = Task.Run(() => this.StringSearch(searchKey, s1, cancellationTokenSources.Token));
                //tasks[2] = Task.Run(() => this.StringSearch(searchKey, s2, cancellationTokenSources.Token));
                //tasks[3] = Task.Run(() => this.StringSearch(searchKey, s3, cancellationTokenSources.Token));

                //tasks[0] = Task.Run(() => this.StringSearch(searchKey, arraySegment[0], cancellationTokenSources.Token));
                //tasks[1] = Task.Run(() => this.StringSearch(searchKey, arraySegment[1], cancellationTokenSources.Token));
                //tasks[2] = Task.Run(() => this.StringSearch(searchKey, arraySegment[2], cancellationTokenSources.Token));
                //tasks[3] = Task.Run(() => this.StringSearch(searchKey, arraySegment[3], cancellationTokenSources.Token));

                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[0], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[1], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[2], cancellationTokenSources.Token)));
                tasks.Add(Task.Run(() => this.StringSearch(searchKey, arraySegment[3], cancellationTokenSources.Token)));

                await tasks[0];
                if (await tasks[0] != null)
                {
                    cancellationTokenSources.Cancel();
                    //GC.EndNoGCRegion();
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm used: 0, " + await tasks[0];
                    return await tasks[0];
                }
                await tasks[1];
                if (await tasks[1] != null)
                {
                    cancellationTokenSources.Cancel();
                    //GC.EndNoGCRegion();
                    //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 1, " + await tasks[1];
                    return await tasks[1];
                }
                //if (s2.Length < s3.Length)
                if (arraySegment[2].Length < arraySegment[3].Length)
                {
                    await tasks[2];
                    if (await tasks[2] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 2, " + await tasks[2];
                        return await tasks[2];
                    }
                    await tasks[3];
                    if (await tasks[3] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 3, " + await tasks[3];
                        return await tasks[3];
                    }
                }
                else
                {
                    await tasks[3];
                    if (await tasks[3] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 3, " + await tasks[3];
                        return await tasks[3];
                    }
                    await tasks[2];
                    if (await tasks[2] != null)
                    {
                        cancellationTokenSources.Cancel();
                        //GC.EndNoGCRegion();
                        //return $"Run Task Number: {upTaskNumber}," + "Algorithm used 2, " + await tasks[2];
                        return await tasks[2];
                    }
                }
                return null;
            }
        }

        private async Task<string> StringSearch(string searchKey, string[] searchDatas, CancellationToken cancellationToken)
        {
            var task = new Task<string>(() =>
            {
                for (int i = 0; i < searchDatas.Length; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        searchKey = null;
                        return null;
                    }

                    if (searchDatas[i].Contains(searchKey))
                        return searchDatas[i];
                }
                return null;
            });
            // Task 실행
            task.Start();
            // task가 종료될 때까지 대기
            await task;
            // task의 결과 리턴
            return task.Result;
        }
    }
}
