import axios from 'axios';
axios.defaults.baseURL= 'https://localhost:7201/api/';
const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url,body) => axios.post(url,body).then(responseBody),
    put: (url,body) => axios.put(url,body).then(responseBody),
    delete: (url) => axios.delete(url).then(responseBody),
};

const Identity = {
    login: (credentials) => requests.post('Identity/login', credentials),
    register: (user) => requests.post('Identity/register', user),
    forgot: (userEmail) => requests.get(`Identity/ForgotPassword?email=${userEmail}`),
    reset: (user) => requests.post('Identity/ResetPassword', user),
    changePassword: (passwordData) => requests.post('Identity/ChangePassword', passwordData),
};

const User = {
    getUserById: (userId) => requests.get(`UserManagment/GetUserById/${userId}`),
    getAllUsers: () => requests.get('UserManagment/GetAllUsers'),
    updateUser: (user) => requests.put('UserManagment/UpdateUser', user),
    updateUserProfilePicture: (user) => requests.put('UserManagment/updateUserProfilePicture', user),
    getUserById: (userId) => requests.get(`UserManagment/GetUserById/${userId}`),
    SearchUser : (searchTerm) => requests.get(`UserManagment/Searchuser/${searchTerm}`),
};

const Team = {
    addTeam: (teamData) => requests.post('Team', teamData),
    editTeam: (teamData) => requests.put('Team', teamData),
    editTeamLogo: (teamData) => requests.put('Team/TeamLogo', teamData),
    deleteTeam: (teamId) => requests.delete(`Team/${teamId}`),
    getTeamById: (teamId) => requests.get(`Team/${teamId}`),
    getTeamsByUserId: (userId) => requests.get(`Team/ByUserId/${userId}`),
    getTeamsUserPlaysFor: (userId) => requests.get(`Team/ThatUserPlaysFor/ByUserId/${userId}`),
    getTeamsByPlayerId: (playerId) => requests.get(`Team/ByPlayerId/${playerId}`),
    getAllTeams: () => requests.get('Team'),
    SearchTeams: (searchTerm) => requests.get(`Team/SearchTeams/${searchTerm}`),
};

const Sport = {
    getAllSports: () => requests.get('Sport'),
    getSportById: (sportId) => requests.get(`Sport/${sportId}`),
};
const Tournament = {
    getTournamentById: (tournamentId) => requests.get(`Tournament/${tournamentId}`),
    getAllTournaments: () => requests.get('Tournament'),
    getTournamentsByUserId: (userId) => requests.get(`Tournament/ByUserId/${userId}`),
    addTournament: (tournamentData) => requests.post('Tournament', tournamentData),
    editTournament: (tournamentData) => requests.put('Tournament', tournamentData),
    editTournamentLogo: (tournamentData) => requests.put('Tournament/TournamentLogo', tournamentData),
    deleteTournament: (tournamentId) => requests.delete(`Tournament/${tournamentId}`),
    addTeamToTournament: (tournamentId, teamId) => requests.put(`Tournament/AddTeam?tournamentId=${tournamentId}&teamId=${teamId}`),
    removeTeamFromTournament: (tournamentId, teamId) => requests.put(`Tournament/RemoveTeam?tournamentId=${tournamentId}&teamId=${teamId}`),
    SearchTournaments: (searchTerm) => requests.get(`Tournament/SearchTournaments/${searchTerm}`),
};

const Player = {
    addPlayer: (playerData) => requests.post('Player/AddPlayer', playerData),
    updatePlayer: (playerData) => requests.put('Player', playerData),
    deletePlayer: (playerId) => requests.delete(`Player/?id=${playerId}`),
    getPlayerById: (playerId) => requests.get(`Player/GetPlayerById/${playerId}`),
    getPlayerByUser: (userId) => requests.get(`Player/PlayerByUser/${userId}`),
    getAllPlayers: () => requests.get('Player/GetAllPlayers'),
    getPlayersByTeam: (teamId) => requests.get(`Player/PlayersByTeam/${teamId}`),
};


const agent = {
    Identity,
    User,
    Team,
    Sport,
    Tournament,
    Player,
}

export default agent;
