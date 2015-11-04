(function () {
    "use strict";

    angular
        .module("app.discussions")
        .controller("DiscussionDetail", DiscussionDetail);

    function DiscussionDetail(discussionsData, postsData, $stateParams, commonServices, $sessionStorage, $state) {
        //var discussionsRootUrl = appSettings.serverPath + "discussions";
        //var postsRootUrl = appSettings.serverPath + "posts";

        var vm = this;

        vm.discussion = '';
        vm.postCount = 0;
        getDiscussion($stateParams.id);

        vm.post = {
            discussionId: $stateParams.id,
            content: ''
        };

        vm.vote = {
            artifactId: '',
            userId: '',
            voteUp: true
        };

        vm.orightml = '';
        vm.htmlcontent = vm.orightml;
        vm.disabled = false;

        function getDiscussion(id) {
            discussionsData.getById(id).then(function (response) {
                if(response.status === 200) {
                vm.discussion = response.data;
                vm.postCount = vm.discussion.posts.length;
                } else {
                    commonServices.showToast('danger', 'There was a problem loading the discussion. Please try again');
                }
            });
        }

        vm.voteUpDiscussion = function () {
            if ($sessionStorage.gadaUser === undefined) {
                $state.go('login');
                return false;
            }

            discussionsData.voteUp(vm.discussion.id).then(function () {
                vm.discussion.votes++;
            });
        }

        vm.voteDownDiscussion = function () {
            if ($sessionStorage.gadaUser === undefined) {
                $state.go('login');
                return false;
            }

            discussionsData.voteDown(vm.discussion.id).then(function () {
                vm.discussion.votes--;
            });
        }

        vm.voteUpPost = function (post) {
            if ($sessionStorage.gadaUser === undefined) {
                $state.go('login');
                return false;
            }

            vm.vote.artifactId = post.id;
            vm.vote.userId = $sessionStorage.gadaUser.id;
            vm.vote.voteUp = true;

            postsData.voteUp(vm.vote).then(function (response) {
                if (response.status === 200) {
                    post.votes++;
                } else {
                    commonServices.showToast('danger', 'You have already voted on this post');
                }
            });
        }

        vm.voteDownPost = function (post) {
            if ($sessionStorage.gadaUser === undefined) {
                $state.go('login');
                return false;
            }

            vm.vote.artifactId = post.id;
            vm.vote.userId = $sessionStorage.gadaUser.id;
            vm.vote.voteUp = false;

            postsData.voteDown(vm.vote).then(function(response) {
                if (response.status === 200) {
                    post.votes--;
                } else {
                    commonServices.showToast('danger', 'You have already voted on this post');
                }
            });
        }


        vm.createPostSubmit = function () {
            if ($sessionStorage.gadaUser === undefined) {
                $state.go('login');
                return false;
            }

            postsData.create(vm.post).then(function (response) {
                if(response.status === 200) {
                    var post = { "id": response.data.id, "post": response.data.post, "posted": "1 second ago", "postedBy": response.data.postedBy, "votes": 0 }
                    vm.discussion.posts.push(post);
                    vm.post.content = '';
                } else {
                    commonServices.showToast('danger', 'There was a problem saving your post. Please try again');
                }
            });
        }
    }

})();