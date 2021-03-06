namespace NEventStore.Contrib.Persistence
{
	using System;
	using System.Data;
	using System.Transactions;

	using NEventStore.Contrib.Persistence.SqlDialects;

	public interface IContribSqlDialect
    {
        string InitializeStorage { get; }
        string PurgeStorage { get; }
        string PurgeBucket { get; }
        string Drop { get; }
        string DeleteStream { get; }

        string GetCommitsFromStartingRevision { get; }
        string GetCommitsFromInstant { get; }
        string GetCommitsFromToInstant { get; }

        string PersistCommit { get; }
        string DuplicateCommit { get; }

        string GetStreamsRequiringSnapshots { get; }
        string GetSnapshot { get; }
        string AppendSnapshotToCommit { get; }

        string GetUndispatchedCommits { get; }
        string MarkCommitAsDispatched { get; }

        string BucketId { get; }
        string StreamId { get; }
        string StreamIdOriginal { get; }
        string StreamRevision { get; }
        string MaxStreamRevision { get; }
        string Items { get; }
        string CommitId { get; }
        string CommitSequence { get; }
        string CommitStamp { get; }
        string CommitStampStart { get; }
        string CommitStampEnd { get; }
        string Headers { get; }
        string Payload { get; }
        string Threshold { get; }

        string Limit { get; }
        string Skip { get; }
        bool CanPage { get; }
        string CheckpointNumber { get; }
        string GetCommitsFromCheckpoint { get; }
        string GetCommitsFromBucketAndCheckpoint { get; }

        object CoalesceParameterValue(object value);

        IDbTransaction OpenTransaction(IDbConnection connection);

        IContribDbStatement BuildStatement(
            TransactionScope scope, IDbConnection connection, IDbTransaction transaction);

        bool IsDuplicate(Exception exception);

        void AddPayloadParamater(IConnectionFactory connectionFactory, IDbConnection connection, IContribDbStatement cmd, byte[] payload);

        DateTime ToDateTime(object value);

        NextPageDelegate NextPageDelegate { get; }
    }
}