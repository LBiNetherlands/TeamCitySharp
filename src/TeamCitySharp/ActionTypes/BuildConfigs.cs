﻿using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class BuildConfigs : IBuildConfigs
    {
        private readonly TeamCityCaller _caller;

        internal BuildConfigs(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<BuildConfig> AllBuildConfigs()
        {
            var buildType = _caller.Get<BuildTypeWrapper>("/app/rest/buildTypes");

            return buildType.BuildType;
        }

        public BuildConfig BuildConfigByConfigurationName(string buildConfigName)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/name:{0}", buildConfigName);

            return build;
        }

        public BuildConfig BuildConfigByConfigurationId(string buildConfigId)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/id:{0}", buildConfigId);

            return build;
        }

        public BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/name:{1}", projectName, buildConfigName));
            return build;
        }

        public BuildConfig BuildConfigByProjectNameAndConfigurationId(string projectName, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/id:{1}", projectName, buildConfigId));
            return build;
        }

        public BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/name:{1}", projectId, buildConfigName));
            return build;
        }

        public BuildConfig BuildConfigByProjectIdAndConfigurationId(string projectId, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/id:{1}", projectId, buildConfigId));
            return build;
        }

        public List<BuildConfig> BuildConfigsByProjectId(string projectId)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/id:{0}/buildTypes", projectId);

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
            return buildWrapper.BuildType;
        }

        public List<BuildConfig> BuildConfigsByProjectName(string projectName)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/name:{0}/buildTypes", projectName);

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
            return buildWrapper.BuildType;
        }

        public BuildConfig CreateConfiguration(string projectName, string configurationName)
        {
            return _caller.PostFormat<BuildConfig>(configurationName, "/app/rest/projects/name:{0}/buildTypes", projectName);
        }



        public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, "/app/rest/buildTypes/{0}/settings/{1}", locator, settingName);
        }





        public void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<ArtifactDependency>(rawXml, "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
        }

        public void PostRawBuildStep(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<BuildConfig>(rawXml, "/app/rest/buildTypes/{0}/steps", locator);
        }

        public void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat(rawXml, "/app/rest/buildTypes/{0}/triggers", locator);
        }

        

        public void SetConfigurationParameter(BuildTypeLocator locator, string key, string value)
        {
            _caller.PutFormat(value, "/app/rest/buildTypes/{0}/parameters/{1}", locator, key);
        }

        public void DeleteConfiguration(BuildTypeLocator locator)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}", locator);
        }

        public void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat(rawXml, "/app/rest/buildTypes/{0}/agent-requirements", locator);
        }

        public void DeleteBuildStep(BuildTypeLocator locator, string buildStepId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/steps/{1}", locator, buildStepId);
        }

        public void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/artifact-dependencies/{1}", locator, artifactDependencyId);
        }

        public void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/agent-requirements/{1}", locator, agentRequirementId);
        }

        public void DeleteParameter(BuildTypeLocator locator, string parameterName)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters/{1}", locator, parameterName);
        }

        public void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/triggers/{1}", locator, buildTriggerId);
        }
    }
}