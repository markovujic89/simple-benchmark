using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmark
    {
        private const string dateTime = "2023-07-17 15:28:45";

        private  readonly DateParser _parser;

        public DateParserBenchmark()
        {
            _parser = new DateParser();
        }

        [Benchmark(Baseline = true)]
        public void GetYerFromDateTime()
        {
            _parser.GetYearFromDateTime(dateTime);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            _parser.GetYearFromSplit(dateTime);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            _parser.GetYearFromSubstring(dateTime);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            _parser.GetYearFromSpan(dateTime);
        }
    }
}
